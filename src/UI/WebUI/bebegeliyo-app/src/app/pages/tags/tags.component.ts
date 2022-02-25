import {Component, OnInit} from '@angular/core';
import {NzTableQueryParams} from "ng-zorro-antd/table";
import {TagService} from 'src/app/services/tag.service';
import {FormBuilder, FormGroup} from "@angular/forms";
import {first} from "rxjs/operators";
import {NzNotificationService} from "ng-zorro-antd/notification";
import {Tag} from "../../models/tag";
import {Title} from "@angular/platform-browser";


@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.css']
})
export class TagsComponent implements OnInit {

  list: any[];
  tag!: Tag;
  formUpdate: FormGroup;
  formAdd: FormGroup;

  total = 1;
  loading = false;
  pageSize = 10;
  pageIndex = 1;
  visibleUpdateDialog = false;
  visibleAddDialog = false;

  constructor(private tagsService: TagService,
              private formBuilder: FormBuilder,
              private title: Title,
              private alert: NzNotificationService) {
    title.setTitle('CMS Etiketler')

  }

  ngOnInit(): void {
    this.formAdd = this.formBuilder.group({
      title: [''],
      description: ['']
    });
    this.formUpdate = this.formBuilder.group({
      id: [],
      title: [''],
      description: ['']
    });
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    const {pageSize, pageIndex} = params;
    this.getAll(pageIndex, pageSize);
  }

  getAll(pageNumber: number, pageSize: number): void {
    this.loading = true;
    this.tagsService.getAll(pageNumber, pageSize).subscribe(response => {
      this.loading = false;
      this.total = response.totalCount;
      this.list = response.data;
    });
  }

  getById(id: number): void {
    let detail = new Tag();
    this.openUpdateDialog();
    this.tagsService.getById(id).pipe(first()).subscribe((response: any) => {
      detail = response.data;
      this.formUpdate.controls['title'].setValue(detail.title)
      this.formUpdate.controls['description'].setValue(detail.description)
      this.formUpdate.controls['id'].setValue(detail.id)
    });
  }

  add(): void {
    const model = new Tag();
    model.title = this.formAdd.value.title;
    model.description = this.formAdd.value.description;

    this.tagsService.add(model).pipe(first()).subscribe((response: any) => {
      if (response.didError) {
        this.alert.error('Başarısız', response.ErrorMessages.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
      } else {
        this.alert.success('Başarılı', 'İşlem başarıyla tamamlandı', {nzAnimate: true, nzDuration: 2000});
        this.visibleAddDialog = false;
        this.getAll(this.pageIndex, this.pageSize);
        this.formAdd.reset();
      }
    }, error => {
      this.alert.error('Başarısız', error.error.errorMessages.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
      this.visibleAddDialog = false;
    });
  }

  update(): void {
    const model = new Tag();

    model.id = this.formUpdate.value.id;
    model.title = this.formUpdate.value.title;
    model.description = this.formUpdate.value.description;

    this.tagsService.update(model).pipe(first()).subscribe((response: any) => {
      if (response.didError) {
        this.alert.error('Başarısız', response.ErrorMessages.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
      } else {
        this.alert.success('Başarılı', 'İşlem başarıyla tamamlandı', {nzAnimate: true, nzDuration: 2000});
        this.visibleUpdateDialog = false;
        this.getAll(this.pageIndex, this.pageSize);
        this.formUpdate.reset();
      }
    }, error => {
      this.alert.error('Başarısız', error.error.errorMessages.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
    })
  }

  delete(): void {
    this.tagsService.delete(this.formUpdate.value.id).pipe(first()).subscribe((response: any) => {
      if (response.didError) {
        this.alert.error('Başarısız', response.ErrorMessages.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
      } else {
        this.alert.success('Başarılı', 'İşlem başarıyla tamamlandı', {nzAnimate: true, nzDuration: 2000});
        this.visibleUpdateDialog = false;
        this.getAll(this.pageIndex, this.pageSize);
        this.formUpdate.reset();
      }
    }, error => {
      this.alert.error('Başarısız', error.error.errorMessages.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
    });
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
