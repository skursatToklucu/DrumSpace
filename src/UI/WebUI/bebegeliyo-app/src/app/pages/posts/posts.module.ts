import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PostsComponent} from "./posts.component";
import {PostsRoutingModule} from "./posts-routing.module";
import {NzButtonModule} from "ng-zorro-antd/button";
import {NzTableModule} from "ng-zorro-antd/table";
import {NzDrawerModule} from "ng-zorro-antd/drawer";
import {NzFormModule} from "ng-zorro-antd/form";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NzInputModule} from "ng-zorro-antd/input";
import {NzDropDownModule} from "ng-zorro-antd/dropdown";
import {NzRadioModule} from "ng-zorro-antd/radio";
import {NzSelectModule} from "ng-zorro-antd/select";



@NgModule({
  declarations: [PostsComponent],
  imports: [
    NzButtonModule,
    CommonModule,
    PostsRoutingModule,
    NzTableModule,
    NzDrawerModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzDropDownModule,
    NzRadioModule,
    FormsModule,
    NzSelectModule
  ],
})
export class PostsModule { }
