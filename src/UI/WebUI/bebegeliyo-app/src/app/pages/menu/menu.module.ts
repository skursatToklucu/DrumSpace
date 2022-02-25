import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MenuComponent} from "./menu.component";
import {RolesComponent} from "../roles/roles.component";
import {MenuRoutingModule} from "./menu-routing.module";
import {NzTableModule} from "ng-zorro-antd/table";
import {NzButtonModule} from "ng-zorro-antd/button";
import {NzDrawerModule} from "ng-zorro-antd/drawer";



@NgModule({
  declarations: [MenuComponent],
  imports: [
    CommonModule,
    MenuRoutingModule,
    NzButtonModule,
    NzTableModule
  ],
  exports: [MenuComponent]
})
export class MenuModule { }
