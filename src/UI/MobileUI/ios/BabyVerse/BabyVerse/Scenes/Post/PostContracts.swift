//
//  PostContracts.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import Foundation

protocol PostViewModelProtocol {
    var delegate: PostViewModelDelegate? { get set }
    func load()
    func selectPost(at index: Int)
}

enum PostViewModelOutputProtocol {
    case updateTitle(String)
    case setLoading(Bool)
    case showPost([PostModel])
}

enum PostViewRoute {
    case detail
}

protocol PostViewModelDelegate {
    func handleViewModelOutput(_ output: PostViewModelOutputProtocol)
    func navigate(to route: PostViewRoute)
}
