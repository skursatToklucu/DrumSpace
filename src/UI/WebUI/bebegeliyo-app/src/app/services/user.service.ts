import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from "../../environments/environment";
import {User} from "../models/user";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) {
  }

  getAll(pageNumber: number, pageSize: number): Observable<any> {
    return this.httpClient.get<any>(`${environment.baseUrl}/users?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  add(model: User): Observable<any>{
    return this.httpClient.post<any>(`${environment.baseUrl}/users`, model);
  }
}
