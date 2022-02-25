//
//  Colors.swift
//  BebeGeliyor
//
//  Created by mdt on 27.11.2021.
//

import UIKit

extension UIColor {
    // MARK: MainBackground
    static var mainBackgroundColor: UIColor {
        if #available(iOS 13.0, *) {
            return UIColor { (traits) -> UIColor in
                // Return one of two colors depending on light or dark mode
                return traits.userInterfaceStyle == .dark ? UIColor(hex: "131621") : UIColor(hex: "F2F2F2")
            }
        } else {
            // Same old color used for iOS 12 and earlier
            return UIColor(red: 0.3, green: 0.4, blue: 0.5, alpha: 1)
        }
    }
    
    // MARK: TextField
    static var textFieldTitleColor: UIColor {
        if #available(iOS 13.0, *) {
            return UIColor { (traits) -> UIColor in
                return traits.userInterfaceStyle == .dark ? UIColor(hex: "FFFFFF") : UIColor(hex: "212149")
            }
        } else {
            return UIColor(hex: "212149")
        }
    }
    
    // MARK: MainBlue
    static var mainBlueColor: UIColor {
        if #available(iOS 13.0, *) {
            return UIColor { (traits) -> UIColor in
                return traits.userInterfaceStyle == .dark ? UIColor(hex: "007AFF") : UIColor(hex: "007AFF")
            }
        } else {
            return UIColor(hex: "007AFF")
        }
    }
    
    // MARK: MainLabel
    static var headerTitleColor: UIColor {
        if #available(iOS 13.0, *) {
            return UIColor { (traits) -> UIColor in
                return traits.userInterfaceStyle == .dark ? UIColor(hex: "111129") : UIColor(hex: "111129")
            }
        } else {
            return UIColor(hex: "111129")
        }
    }
    
    // MARK: BodyTitle
    static var bodyTitleColor: UIColor {
        if #available(iOS 13.0, *) {
            return UIColor { (traits) -> UIColor in
                return traits.userInterfaceStyle == .dark ? UIColor(hex: "212338") : UIColor(hex: "212338")
            }
        } else {
            return UIColor(hex: "212338")
        }
    }
}


extension UIColor {
    convenience init(hex: String) {
        let hex = hex.trimmingCharacters(in: CharacterSet.alphanumerics.inverted)
        var int = UInt32()
        Scanner(string: hex).scanHexInt32(&int)
        let a, r, g, b: UInt32
        switch hex.count {
            case 3: // RGB (12-bit)
                (a, r, g, b) = (255, (int >> 8) * 17, (int >> 4 & 0xF) * 17, (int & 0xF) * 17)
            case 6: // RGB (24-bit)
                (a, r, g, b) = (255, int >> 16, int >> 8 & 0xFF, int & 0xFF)
            case 8: // ARGB (32-bit)
                (a, r, g, b) = (int >> 24, int >> 16 & 0xFF, int >> 8 & 0xFF, int & 0xFF)
            default:
                (a, r, g, b) = (255, 0, 0, 0)
        }
        self.init(red: CGFloat(r) / 255, green: CGFloat(g) / 255, blue: CGFloat(b) / 255, alpha: CGFloat(a) / 255)
    }

}

