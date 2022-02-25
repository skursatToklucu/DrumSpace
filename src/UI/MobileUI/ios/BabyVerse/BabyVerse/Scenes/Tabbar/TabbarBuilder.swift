//
//  TabbarBuilder.swift
//  BabyVerse
//
//  Created by mdt on 30.11.2021.
//

import Foundation
import UIKit

final class TabbarBuilder {
    static func make() -> TabbarVC {
        let storyboard = UIStoryboard(name: "Tabbar", bundle: nil)
        let viewController = storyboard.instantiateViewController(withIdentifier: "TabbarVC") as! TabbarVC
//        viewController.viewModel = TabbarViewModel()
        return viewController
    }
}
