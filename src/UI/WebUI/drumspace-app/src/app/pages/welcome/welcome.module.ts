import {NgModule} from '@angular/core';
import {WelcomeRoutingModule} from './welcome-routing.module';
import {WelcomeComponent} from './welcome.component';
import {NzGridModule} from "ng-zorro-antd/grid";
import {FormsModule} from '@angular/forms';
import {FabricjsEditorModule} from "../../_helpers/projects/lib/angular-editor-fabric-js.module";


@NgModule({
  imports: [WelcomeRoutingModule, NzGridModule, FabricjsEditorModule, FormsModule],
  declarations: [WelcomeComponent],
  exports: [WelcomeComponent],
  bootstrap: [WelcomeComponent]
})
export class WelcomeModule {
}
