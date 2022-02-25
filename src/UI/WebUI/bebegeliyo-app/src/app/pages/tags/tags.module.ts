import {NgModule} from '@angular/core';
import {TagsRoutingModule} from './tags-routing.module';
import {TagsComponent} from './tags.component';
import {NzTableModule} from "ng-zorro-antd/table";
import {CommonModule} from "@angular/common";
import {NzListModule} from "ng-zorro-antd/list";
import {NzButtonModule} from "ng-zorro-antd/button";
import {NzDrawerModule} from "ng-zorro-antd/drawer";
import {NzFormModule} from "ng-zorro-antd/form";
import {NzInputModule} from "ng-zorro-antd/input";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NzAlertModule} from "ng-zorro-antd/alert";
import {NzSelectModule} from "ng-zorro-antd/select";


@NgModule({
    imports: [
      TagsRoutingModule,
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
      NzSelectModule
    ],
  declarations: [TagsComponent],
  exports: [TagsComponent]
})
export class TagsModule {
}
