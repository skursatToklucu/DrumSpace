//
//  AppContainer.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import Foundation

let app = AppContainer()

final class AppContainer {
    let router = AppRouter()
    let service = AppService()
}
