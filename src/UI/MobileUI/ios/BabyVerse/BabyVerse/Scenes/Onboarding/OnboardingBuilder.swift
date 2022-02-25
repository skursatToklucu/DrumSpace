//
//  OnboardingBuilder.swift
//  BabyVerse
//
//  Created by mdt on 30.11.2021.
//

import UIKit

final class OnboardingBuilder {
    static func make() -> OnboardingVC {
        let storyboard = UIStoryboard(name: "OnboardingVC", bundle: nil)
        let viewController = storyboard.instantiateViewController(withIdentifier: "OnboardingVC") as! OnboardingVC
        
        return viewController
    }
}
