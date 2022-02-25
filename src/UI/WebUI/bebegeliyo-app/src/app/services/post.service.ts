import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) {
  }

  getAll(pageNumber: number, pageSize: number): Observable<any> {
    return this.http.get<any>(`${environment.baseUrl}/posts?PageNumber=${pageNumber}&PageSize=${pageSize}`);
  }

  getById(id: number): Observable<any> {
  return this.http.get<any>(`${environment.baseUrl}/posts/${id}`);
  }

  add(model: any): Observable<any>{
    return this.http.post<any>(`${environment.baseUrl}/posts`, model);
  }

  update(model: any): Observable<any>{
    return this.http.put<any>(`${environment.baseUrl}/posts`, model);
  }

  delete(model: any): Observable<any>{
    return this.http.delete<any>(`${environment.baseUrl}/posts`, model);
  }
}
