//
//  PostModel.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import Foundation
import ObjectMapper

class PostModel: Mappable {
    var id: Int!
    var title: String!
    var createdBy: String!
    var tags: [PostTags]!
    var postType: PostType!
    var commentCount: Int!
    
    required init?(map: Map) {
        
    }
    
    func mapping(map: Map) {
        id <- map["id"]
        title <- map["title"]
        createdBy <- map["createdBy"]
        tags <- map["tags"]
        postType <- map["postType"]
        commentCount <- map["commentCount"]
    }
    
    
}

class PostTags: Mappable {
    var title: String!
    var colourHexCode: String!
    
    required init?(map: Map) {
        
    }
    
    func mapping(map: Map) {
        title <- map["title"]
        colourHexCode <- map["colourHexCode"]
    }
}


enum PostType: Int {
    case text = 0
    case photo = 1
    case video = 2
}
