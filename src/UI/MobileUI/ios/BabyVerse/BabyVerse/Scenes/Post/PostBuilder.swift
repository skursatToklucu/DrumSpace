//
//  PostBuilder.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import UIKit

final class PostBuilder {
    static func make() -> PostVC {
        let storyboard = UIStoryboard(name: "PostVC", bundle: nil)
        let viewController = storyboard.instantiateViewController(withIdentifier: "PostVC") as! PostVC
        viewController.viewModel = PostViewModel()
        return viewController
    }
}

