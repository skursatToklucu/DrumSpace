import {NgModule} from '@angular/core';
import {UsersRoutingModule} from './users-routing.module';
import {UsersComponent} from './users.component';
import {NzTableModule} from "ng-zorro-antd/table";
import {CommonModule} from "@angular/common";
import {NzListModule} from "ng-zorro-antd/list";
import {NzDrawerModule} from "ng-zorro-antd/drawer";
import {NzFormModule} from "ng-zorro-antd/form";
import {NzInputModule} from "ng-zorro-antd/input";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NzButtonModule} from "ng-zorro-antd/button";
import {NzAlertModule} from "ng-zorro-antd/alert";
import {NzSelectModule} from "ng-zorro-antd/select";
import {NzCheckboxModule} from "ng-zorro-antd/checkbox";

@NgModule({
    imports: [
        UsersRoutingModule,
        NzTableModule,
        CommonModule,
        NzListModule,
        NzButtonModule,
        NzDrawerModule,
        NzFormModule,
        NzInputModule,
        ReactiveFormsModule,
        NzAlertModule,
        FormsModule,
        NzSelectModule,
        NzCheckboxModule
    ],
  declarations: [UsersComponent],
  exports: [UsersComponent]
})

export class UsersModule {
}
