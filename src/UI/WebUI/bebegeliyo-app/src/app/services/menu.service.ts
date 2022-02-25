import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor(private http: HttpClient) { }


  getAll(pageNumber: number, pageSize: number): Observable<any>{
    return this.http.get<any>(`${environment.baseUrl}/menu?PageNumber=${pageNumber}&PageSize=${pageSize}`);
  }
}
