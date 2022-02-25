//
//  PostVC.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import UIKit

class PostVC: UIViewController {
    
    @IBOutlet weak var postTableView: UITableView!
    
    var viewModel: PostViewModelProtocol! {
        didSet {
            viewModel.delegate = self
        }
    }
    
    var isScrolledToTop: Bool {
        for subView in view.subviews {
            if let scrollView = subView as? UIScrollView {
                return (scrollView.contentOffset.y == 0)
            }
        }
        return true
    }
    
    private var postList: [PostModel] = []

    override func viewDidLoad() {
        super.viewDidLoad()
        viewModel.load()
        
        postTableView.delegate = self
        postTableView.dataSource = self
        
        postTableView.register(UINib(nibName: "PostTableViewCell", bundle: nil), forCellReuseIdentifier: "PostTableViewCell")
        
        postTableView.rowHeight = UITableView.automaticDimension
        postTableView.estimatedRowHeight = 156
        initUI()
    }
    
    private func initUI() {
        view.backgroundColor = .mainBackgroundColor
        postTableView.backgroundColor = .mainBackgroundColor
    }


}

extension PostVC: PostViewModelDelegate {
    func handleViewModelOutput(_ output: PostViewModelOutputProtocol) {
        switch output {
            case .updateTitle(let title):
                self.title = title
            case .setLoading(let isLoading):
                UIApplication.shared.isNetworkActivityIndicatorVisible = isLoading
            case .showPost(let postList):
                self.postList = postList
                print("PostList: \(self.postList)")
                postTableView.reloadData()
        }
    }
    
    func navigate(to route: PostViewRoute) {
        
    }
    
    
}


extension PostVC: UITableViewDelegate {
    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat {
        return UITableView.automaticDimension
    }
}

extension PostVC: UITableViewDataSource {
    func numberOfSections(in tableView: UITableView) -> Int {
        return 1
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return postList.count
    }

    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "PostTableViewCell", for: indexPath) as! PostTableViewCell
        cell.setCell(postModel: postList[indexPath.row])
        
        
        return cell
    }
    
    


}
