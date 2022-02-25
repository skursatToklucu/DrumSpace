//
//  OnboardingVC.swift
//  BabyVerse
//
//  Created by mdt on 30.11.2021.
//

import UIKit

class OnboardingVC: UIViewController {

    @IBOutlet weak var imageView: UIImageView!
    @IBOutlet weak var titleLabel: UILabel!
    @IBOutlet weak var descriptionLabel: UILabel!
    @IBOutlet weak var joinNowButton: UIButton!
    @IBOutlet weak var signInButton: UIButton!
    
    override func viewDidLoad() {
        super.viewDidLoad()

        initUI()
    }


    private func initUI() {
        titleLabel.font = .medium(size: 22)
        descriptionLabel.font = .regular(size: 14)

        titleLabel.text = "Muhammet Dikran Teymur"
        
        joinNowButton.makeDefaultBlueButton(title: "Şimdi Katıl")
        signInButton.setTitle("Giriş Yap", for: .normal)
        signInButton.setTitleColor(.mainBlueColor, for: .normal)
        
    }
}
