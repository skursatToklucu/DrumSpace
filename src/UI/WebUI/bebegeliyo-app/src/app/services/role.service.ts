import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from "../../environments/environment";
import {Role} from "../models/role";
import {Tag} from "../models/tag";

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private httpClient: HttpClient) {
  }

  getAll(pageNumber: number, pageSize: number): Observable<any> {
    return this.httpClient.get<any>(`${environment.baseUrl}/roles?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  getById(id: string): Observable<Tag> {
    return this.httpClient.get<Tag>(`${environment.baseUrl}/roles/detail?roleId=${id}`);
  }

  add(model: Role): Observable<any> {
    return this.httpClient.post<any>(`${environment.baseUrl}/roles`, model);
  }

  update() {

  }

  delete(id: string): Observable<any> {
    return this.httpClient.delete<any>(`${environment.baseUrl}/roles/${id}`);
  }
}
