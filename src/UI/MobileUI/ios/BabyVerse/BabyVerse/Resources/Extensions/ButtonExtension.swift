//
//  ButtonExtension.swift
//  BabyVerse
//
//  Created by mdt on 30.11.2021.
//

import UIKit

extension UIButton {
    func makeDefaultBlueButton(title: String) {
        layer.cornerRadius = 10
        backgroundColor = .mainBlueColor
        setTitle(title, for: .normal)
//        titleLabel?.font = .regular(size: 14)
    }
}
