import {Component, OnInit} from '@angular/core';
import {NzTableQueryParams} from "ng-zorro-antd/table";
import {RoleService} from 'src/app/services/role.service';
import {FormGroup, FormBuilder} from "@angular/forms";
import {Title} from "@angular/platform-browser";
import {NzNotificationService} from "ng-zorro-antd/notification";
import {Role} from "../../models/role";
import {first} from "rxjs/operators";

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent implements OnInit {

  list: any[];
  role!: Role;
  formUpdate: FormGroup;
  formAdd: FormGroup;

  total = 1;
  loading = false;
  pageSize = 10;
  pageIndex = 1;
  visibleUpdateDialog = false;
  visibleAddDialog = false;

  constructor(private rolesService: RoleService,
              private formBuilder: FormBuilder,
              private title: Title,
              private alert: NzNotificationService) {
    title.setTitle('CMS Roller')
  }

  ngOnInit(): void {
    this.formAdd = this.formBuilder.group({
      name: ['']
    });
    this.formUpdate = this.formBuilder.group({
      id: [],
      name: ['']
    });
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    const {pageSize, pageIndex} = params;
    this.getAll(pageIndex, pageSize);
  }

  getAll(pageNumber: number, pageSize: number): void {
    this.loading = true;
    this.rolesService.getAll(pageNumber, pageSize).subscribe((response: any) => {
      this.loading = false;
      this.total = response.totalCount;
      this.list = response.data;
    });
  }

  update(): void {

  }

  add(): void {
    const model = new Role();
    model.name = this.formAdd.value.name;

    this.rolesService.add(model).pipe(first()).subscribe((response: any) => {
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
    })
  }

  delete(): void {
    this.rolesService.delete(this.formUpdate.value.id).pipe(first()).subscribe((response: any) => {
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
