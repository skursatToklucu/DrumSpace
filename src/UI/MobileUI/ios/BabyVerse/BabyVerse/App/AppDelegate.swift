//
//  AppDelegate.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import UIKit

@main
class AppDelegate: UIResponder, UIApplicationDelegate {

    func application(_ application: UIApplication, didFinishLaunchingWithOptions launchOptions: [UIApplication.LaunchOptionsKey: Any]?) -> Bool {
//        app.router.start()
        app.router.startWithTabbar()
        
        // TODO: - if user login or not

        // TODO: - if onboarding show or not
        if UserDefaults.isShowOnboarding {
            app.router.startWithTabbar()
        } else {
            app.router.startOnboarding()
        }
        return true
    }



}

