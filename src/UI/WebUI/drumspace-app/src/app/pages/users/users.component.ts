import {Component, OnInit} from '@angular/core';
import {NzTableQueryParams} from "ng-zorro-antd/table";
import {UserService} from 'src/app/services/user.service';
import {FormBuilder, FormGroup} from "@angular/forms";
import {NzNotificationService} from "ng-zorro-antd/notification";
import {AddUser, User} from "../../models/user";
import {first} from "rxjs/operators";
import {Title} from "@angular/platform-browser";
import {RoleService} from "../../services/role.service";
import {Role} from "../../models/role";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  list: any[];
  roleList: Role[];
  selectedRoles = [];
  user!: User;
  formUpdate: FormGroup;
  formAdd: FormGroup;

  total = 1;
  loading = false;
  pageSize = 10;
  pageIndex = 1;
  visibleUpdateDialog = false;
  visibleAddDialog = false;

  constructor(private usersService: UserService,
              private formBuilder: FormBuilder,
              private roleService: RoleService,
              private title: Title,
              private alert: NzNotificationService) {
    title.setTitle('CMS Kullanıcılar')
  }

  ngOnInit(): void {
    this.formAdd = this.formBuilder.group({
      userId: [''],
      roleIds: [[]]
    });
    this.formUpdate = this.formBuilder.group({
      userId: [''],
      roleIds: [[]]
    });
    this.getRoles();
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    const {pageSize, pageIndex} = params;
    this.getAll(pageIndex, pageSize);
  }

  getAll(pageNumber: number, pageSize: number): void {
    this.loading = true;
    this.usersService.getAll(pageNumber, pageSize).pipe(first()).subscribe(response => {
      this.loading = false;
      this.total = response.totalCount;
      this.list = response.data;
    });
  }

  getRoles(): void {
    this.roleService.getAll(1, 50).pipe(first()).subscribe((response: any) => {
      this.roleList = response.data;
    });
  }

  getById(id: number): void {
    this.openUpdateDialog();
  }

  add(): void {
    const model = new AddUser();
    model.userId = this.formAdd.value.userId;
    model.roleIds = this.selectedRoles;
    // this.usersService.add(model).pipe(first()).subscribe((response: any) => {
    //   if (response.didError) {
    //     this.alert.error('Başarısız', response.ErrorMessages.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
    //   } else {
    //     this.alert.success('Başarılı', 'İşlem başarıyla tamamlandı', {nzAnimate: true, nzDuration: 2000});
    //     this.visibleAddDialog = false;
    //     this.getAll(this.pageIndex, this.pageSize);
    //     this.formAdd.reset();
    //   }
    // }, error => {
    //   this.alert.error('Başarısız', error.error.errorMessages.join('\r\n'), {nzAnimate: true, nzDuration: 2000});
    //   this.visibleAddDialog = false;
    // })
    console.log(model);
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

  selectedRole(event: object[]) {
    const children: Array<{ label: string; value: string }> = [];
    for (let i = 10; i < 36; i++) {
      children.push({ label: i.toString(36) + i, value: i.toString(36) + i });
    }
    this.selectedRoles = children;
  }
}
