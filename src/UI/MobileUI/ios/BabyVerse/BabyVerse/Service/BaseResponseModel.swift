//
//  BaseResponseModel.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import Foundation
import ObjectMapper


class BaseResponseModel: Mappable {
    var message: String?
    var didError: Bool?
    var errorMessages: [String]?
    var data: String?
    var pageIndex: Int?
    var totalPages: Int?
    var totalCount: Int?
    var hasPreviousPage: Bool?
    var hasNextPage: Bool?
    
    init() { }
    
    required init?(map: Map) {
        
    }
    
    func mapping(map: Map) {
        message <- map["message"]
        didError <- map["didError"]
        errorMessages <- map["errorMessages"]
        data <- map["data"]
        pageIndex <- map["pageIndex"]
        totalPages <- map["totalPages"]
        totalCount <- map["totalCount"]
        hasPreviousPage <- map["hasPreviousPage"]
        hasNextPage <- map["hasNextPage"]
    }

}

class DataResponseModel: Mappable {
    var id: Int?
    var createdAt: String?
    var modifiedAt: String?
    var isStatus: Bool?
    var isDeleted: Bool?
    var description: String?
    var like: Int?
    var userId: Int?
    var postId: Int?
    var post: String?
    
    required init?(map: Map) {
        
    }
    
    func mapping(map: Map) {
        id <- map["id"]
        createdAt <- map["createdAt"]
        modifiedAt <- map["modifiedAt"]
        isStatus <- map["isStatus"]
        isDeleted <- map["isDeleted"]
        description <- map["description"]
        like <- map["like"]
        userId <- map["userId"]
        postId <- map["postId"]
        post <- map["post"]
    }
    
    
}
