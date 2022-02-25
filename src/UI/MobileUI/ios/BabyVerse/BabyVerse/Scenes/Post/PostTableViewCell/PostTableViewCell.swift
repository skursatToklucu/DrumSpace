//
//  PostTableViewCell.swift
//  BebeGeliyor
//
//  Created by mdt on 28.11.2021.
//

import UIKit

class PostTableViewCell: UITableViewCell {
    
    @IBOutlet weak var mainView: UIView!
    @IBOutlet weak var profileImageView: UIImageView!
    @IBOutlet weak var profileNameLabel: UILabel!
    @IBOutlet weak var postTitleLabel: UILabel!
    @IBOutlet weak var likeButtton: UIButton!
    @IBOutlet weak var commentButton: UIButton!
    @IBOutlet weak var tagsStackView: UIStackView!
    
    var postModel: PostModel?
    var allTags: [PostTags] = []
    
    override func layoutSubviews() {
        super.layoutSubviews()
    }
    
    override func awakeFromNib() {
        super.awakeFromNib()
        
        initUI()
    
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        
    }
    
    override func prepareForReuse() {
        super.prepareForReuse()
        for i in tagsStackView.arrangedSubviews {
            i.removeFromSuperview()
        }
    }
    
    private func initUI() {
        mainView.layer.cornerRadius = 15
        mainView.backgroundColor = .white
        profileImageView.image = UIImage(named: "man")

//        profileNameLabel.font = .deneme16
        
    }
    
    func setCell(postModel: PostModel) {
        self.postModel = postModel
        
        switch postModel.postType {
            case .text:
                print("post type is text")
                break
            case .photo:
                print("post type is photo")
                break
            case .video:
                print("post type is video")
                break
            case .none:
                print("post type is none")
                break
        }
        
        profileImageView.layer.borderColor = UIColor.gray.cgColor
        profileImageView.layer.borderWidth = 1
        profileImageView.layer.cornerRadius = profileImageView.bounds.height / 2
        profileImageView.layer.masksToBounds = true
        
        profileNameLabel.text = postModel.createdBy
        postTitleLabel.text = postModel.title
        
        likeButtton.setTitle("86", for: .normal)
        likeButtton.setTitleColor(.headerTitleColor, for: .normal)
//        likeButtton.titleLabel?.adjustsFontSizeToFitWidth = true
        
        commentButton.setTitle(String(postModel.commentCount), for: .normal)
        commentButton.titleLabel?.font = UIFont(name: "SF-Pro-Text-Medium", size: 12)
        commentButton.setTitleColor(.headerTitleColor, for: .normal)
        
        setTagsStackView(tags: postModel.tags)
        
        
        
    }
    
    private func setTagsStackView(tags: [PostTags]) {
        tagsStackView.axis = .horizontal
        tagsStackView.spacing = 8
        tagsStackView.alignment = .center
        tagsStackView.distribution = .equalSpacing

        if !tags.isEmpty {
            for i in tagsStackView.arrangedSubviews {
                i.removeFromSuperview()
            }
            
            for tag in tags {
                let tagview = TagView()
                tagview.backgroundColor = .red
                tagview.setTagView(tag: tag)
                tagsStackView.addArrangedSubview(tagview)
                
            }
            
        }
        
    }

}
