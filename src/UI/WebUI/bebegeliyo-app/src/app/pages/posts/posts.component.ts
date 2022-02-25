import {Component, OnInit} from '@angular/core';
import {PostService} from "../../services/post.service";
import {Title} from "@angular/platform-browser";
import {FormBuilder, FormGroup} from "@angular/forms";
import {NzTableQueryParams} from "ng-zorro-antd/table";
import {Post} from "../../models/post";
import {first} from "rxjs/operators";
import {NzNotificationService} from "ng-zorro-antd/notification";
import {Tag} from "../../models/tag";
import {TagService} from "../../services/tag.service";

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  list: any[];
  post!: Post;
  tagList: Tag[];
  formUpdate: FormGroup;
  formAdd: FormGroup;
  selectedTags: Tag[];

  total = 1;
  loading = false;
  pageSize = 10;
  pageIndex = 1;
  visibleUpdateDialog = false;
  visibleAddDialog = false;
  postTypeValue!: any;

  postTypes = [
    {id: 0, value: 'Metin'},
    {id: 1, value: 'Fotoğraf'},
    {id: 2, value: 'Video'}
  ]

  constructor(private postService: PostService,
              private formBuilder: FormBuilder,
              private tagService: TagService,
              private alert: NzNotificationService,
              private title: Title) {
    title.setTitle('CMS Gönderiler')
  }

  ngOnInit(): void {
    this.formUpdate = this.formBuilder.group({
      id: [],
      title: [''],
      postType: [],
      tags: [[]],
      content: [''],
      description: ['']
    });
    this.formAdd = this.formBuilder.group({
      title: [''],
      postType: [],
      tags: [[]],
      content: [''],
      description: ['']
    });
    this.getAllTag();
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    const {pageSize, pageIndex} = params;
    this.getAll(pageIndex, pageSize);
  }

  getAll(pageNumber: number, pageSize: number): void {
    this.loading = true;
    this.postService.getAll(pageNumber, pageSize).subscribe(response => {
      this.loading = false;
      this.total = response.totalCount;
      this.list = response.data;
    });
  }

  getAllTag(): void {
    this.tagService.getAll(1, 50).pipe(first()).subscribe((response: any) => {
      this.tagList = response.data;
    })
  }

  getById(id: number): void {
    let detail = new Post();
    this.openUpdateDialog();
    this.postService.getById(id).pipe(first()).subscribe((response: any) => {
      if (!response.didError) {
        detail = response.data;
        this.selectedTags = response.data.tags;
        this.formUpdate.controls['title'].setValue(detail.title);
        this.formUpdate.controls['description'].setValue(detail.description);
        this.formUpdate.controls['postType'].setValue(detail.postType);
        this.formUpdate.controls['id'].setValue(detail.id);
      }
    });
  }

  add(): void {
    const model = new Post();
    model.title = this.formAdd.value.title;
    model.description = this.formAdd.value.description;
    model.postType = 0;
    model.tags = this.selectedTags;
    this.postService.add(model).pipe(first()).subscribe((response: any) => {
      if (response.didError) {
        this.alert.error('Başarısız', response.ErrorMessages.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
      } else {
        this.alert.success('Başarılı', 'İşlem başarıyla tamamlandı', {nzAnimate: true, nzDuration: 2000});
        this.visibleAddDialog = false;
        this.getAll(this.pageIndex, this.pageSize);
        this.formAdd.reset();
      }
    }, error => {
      this.alert.error('Başarısız', error.error.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
    });

  }


  update(): void {

  }

  delete(): void {

  }

  openAddDialog(): void {
    this.visibleAddDialog = true;
  }

  closeAddDialog(): void {
    this.visibleAddDialog = false;
    this.formAdd.reset();
  }

  openUpdateDialog(): void {
    this.visibleUpdateDialog = true;
  }

  closeUpdateDialog(): void {
    this.visibleUpdateDialog = false;
  }
}
