//
//  PostViewModel.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import Foundation
import ObjectMapper
import SwiftyJSON

final class PostViewModel: PostViewModelProtocol {
    var delegate: PostViewModelDelegate?
    private var posts: [PostModel] = []
    
    func load() {
        delegate?.handleViewModelOutput(.updateTitle("Forum Posts"))
        delegate?.handleViewModelOutput(.setLoading(true))
        
        let url = "/api/Posts"
        AppService.sendRequest(requestMethod: .get, url: url, params: nil) { result in
            switch result {
                case .success(let model):
                    print("model.data: \(model.data ?? "yok")")
                    if let didError = model.didError, let data = model.data {
                        if !didError {
                            if let data = Mapper<PostModel>().mapArray(JSONString: data) {
                                self.posts = data
                                self.delegate?.handleViewModelOutput(.showPost(self.posts))
                            }
                            
                        }
                    }
                case .failure(let error):
                    print("error: \(error)")
                    
            }
        }
        
        
    }
    
    func selectPost(at index: Int) {
        if posts.isEmpty {
            print("error")
        } else {
            let post = posts[index]
            print("selected post: \(post)")
        }
    }
    
    
}
