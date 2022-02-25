import {NgModule} from '@angular/core';
import {RolesRoutingModule} from './roles-routing.module';
import {RolesComponent} from './roles.component';
import {NzTableModule} from "ng-zorro-antd/table";
import {CommonModule} from "@angular/common";
import {NzListModule} from "ng-zorro-antd/list";
import {NzFormModule} from "ng-zorro-antd/form";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NzDrawerModule} from "ng-zorro-antd/drawer";
import {NzInputModule} from "ng-zorro-antd/input";
import {NzButtonModule} from "ng-zorro-antd/button";
import {NzAlertModule} from "ng-zorro-antd/alert";
import {NzSelectModule} from "ng-zorro-antd/select";

@NgModule({
  imports: [RolesRoutingModule,
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
    NzSelectModule],
  declarations: [RolesComponent],
  exports: [RolesComponent]
})
export class RolesModule {
}
