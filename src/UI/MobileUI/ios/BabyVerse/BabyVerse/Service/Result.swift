//
//  Result.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import Foundation
import Alamofire

public enum Result<Value> {
    case success(Value)
    case failure(AFError)
}
