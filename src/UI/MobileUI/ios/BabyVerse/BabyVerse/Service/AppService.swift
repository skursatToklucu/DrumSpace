//
//  AppService.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import Foundation
import Alamofire
import ObjectMapper
import SwiftyJSON

final class AppService {
    static let baseUrl = "http://194.5.236.155"
    
    let token: String = ""
    
    static let headers: HTTPHeaders = [
        .authorization(bearerToken: ""),
        .accept("application/json")
    ]
    
    
    public init() {
        
        
    
    }
    
    class func sendRequest(requestMethod: HTTPMethod, url: String, params: Parameters?, completion: @escaping (Result<BaseResponseModel>) -> Void) {
        let fullUrl = baseUrl + url
        print("fullUrl: \(fullUrl)")
        var baseResponseModel = BaseResponseModel()
        
        AF.request(fullUrl, method: requestMethod, parameters: params, encoding: JSONEncoding.default, headers: headers).responseJSON { response in
            switch response.result {
                case .success(let value):
                    let result = value as! NSDictionary
                    
                    if let model = Mapper<BaseResponseModel>().map(JSONObject: result) {
                        baseResponseModel = model
                    }
                    
                    if let data = result.value(forKey: "data") {
                        baseResponseModel.data = JSON(data).rawString()
                        baseResponseModel.didError = false
                    }
                    
                    completion(.success(baseResponseModel))
                    
                case .failure(let error):
                    print("hata: \(error)")
                    completion(.failure(error))
            }
        }
    }
    

}


