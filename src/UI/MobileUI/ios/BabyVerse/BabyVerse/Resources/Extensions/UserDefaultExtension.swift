//
//  UserDefaultExtension.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import Foundation

extension UserDefaults {
    private enum Status: String {
        case isDarkMode = "isDarkMode"
        case isUserLogin = "isUserLogin"
        case isShowOnboarding = "isShowOnboarding"
        
        var name: String {
            get {
                return self.rawValue
            }
        }
    }
    
    class var isDarkMode: Bool {
        get {
            return UserDefaults.standard.bool(forKey: Status.isDarkMode.name)
        }
        
        set {
            UserDefaults.standard.setValue(newValue, forKey: Status.isDarkMode.name)
        }
    }
    
    class var isUserLogin: Bool {
        get {
            return UserDefaults.standard.bool(forKey: Status.isUserLogin.name)
        }
        
        set {
            UserDefaults.standard.setValue(newValue, forKey: Status.isUserLogin.name)
        }
    }
    
    class var isShowOnboarding: Bool {
        get {
            return UserDefaults.standard.bool(forKey: Status.isShowOnboarding.name)
        }
        
        set {
            UserDefaults.standard.setValue(newValue, forKey: Status.isShowOnboarding.name)
        }
    }
    

}
