//
//  TagView.swift
//  BabyVerse
//
//  Created by mdt on 30.11.2021.
//

import UIKit

class TagView: UIView {

    @IBOutlet weak var mainView: UIView!
    @IBOutlet weak var tagNameLabel: UILabel!
    
    var tagModel: PostTags?
    
    override init(frame: CGRect) {
        super.init(frame: frame)
        commonInit()
    }
    
    required init?(coder: NSCoder) {
        super.init(coder: coder)
        commonInit()
    }
    
    private func commonInit() {
        let view = Bundle.main.loadNibNamed("TagView", owner: self, options: nil)!.first as! UIView
        view.frame = self.bounds
        view.autoresizingMask = [.flexibleWidth, .flexibleHeight]
        addSubview(view)
        initUI()
    }
    
    private func initUI() {
        mainView.layer.cornerRadius = tagNameLabel.bounds.height / 2
        tagNameLabel.textColor = .white
        
    }

    func setTagView(tag: PostTags) {
        if let color = tag.colourHexCode, let title = tag.title {
            mainView.backgroundColor = UIColor(hex: color)
            self.tagNameLabel.text = title
            
        }
    }
}
