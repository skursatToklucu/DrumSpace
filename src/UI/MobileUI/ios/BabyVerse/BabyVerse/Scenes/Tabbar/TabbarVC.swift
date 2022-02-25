//
//  TabbarController.swift
//  BabyVerse
//
//  Created by mdt on 30.11.2021.
//

import UIKit

class TabbarVC: UITabBarController {

    override func viewDidLoad() {
        super.viewDidLoad()

        
        

    }
    
    override func viewDidAppear(_ animated: Bool) {
        super.viewDidAppear(animated)
        
        let postVC = PostBuilder.make()
        let postVCTabbarItem = UITabBarItem(title: "Home", image: UIImage(named: "tabbar.home"), selectedImage: UIImage(named: "tabbar.home"))
        postVC.tabBarItem = postVCTabbarItem
//        let notificationVC = NotificationBuilder.make()
//        let addPostVC = NotificationBuilder.make()
//        let searchVC = NotificationBuilder.make()
//        let profileVC = NotificationBuilder.make()
//        self.selectedIndex = 0
        viewControllers = [postVC]
    }


}
