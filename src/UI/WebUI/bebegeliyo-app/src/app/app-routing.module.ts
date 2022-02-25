import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '/welcome'},
  {path: 'welcome', loadChildren: () => import('./pages/welcome/welcome.module').then(m => m.WelcomeModule)},
  {path: 'users', loadChildren: () => import('./pages/users/users.module').then(m => m.UsersModule)},
  {path: 'roles', loadChildren: () => import('./pages/roles/roles.module').then(m => m.RolesModule)},
  {path: 'tags', loadChildren: () => import('./pages/tags/tags.module').then(m => m.TagsModule)},
  {path: 'posts', loadChildren: () => import('./pages/posts/posts.module').then(m=>m.PostsModule)},
  {path: 'menu', loadChildren: () => import('./pages/menu/menu.module').then(m=>m.MenuModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
