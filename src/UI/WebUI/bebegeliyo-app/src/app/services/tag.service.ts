import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from "../../environments/environment";
import {Tag} from "../models/tag";


@Injectable({
  providedIn: 'root'
})
export class TagService {

  constructor(private httpClient: HttpClient) {
  }

  getAll(pageNumber: number, pageSize: number): Observable<any> {
    return this.httpClient.get<any>(`${environment.baseUrl}/tags?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  add(model: Tag): Observable<Tag> {
    return this.httpClient.post<Tag>(`${environment.baseUrl}/tags`, model);
  }

  update(model: Tag): Observable<any> {
    return this.httpClient.put<any>(`${environment.baseUrl}/tags/${model.id}`, model)
  }

  delete(id: number): Observable<any> {
    return this.httpClient.delete<any>(`${environment.baseUrl}/tags/${id}`);
  }

  getById(id: number): Observable<any> {
    return this.httpClient.get<any>(`${environment.baseUrl}/tags/${id}`);
  }
}
