import {Component, OnInit} from '@angular/core';
import {MenuService} from "../../services/menu.service";
import {Menu} from "../../models/menu";
import {first} from "rxjs/operators";
import {NzTableQueryParams} from "ng-zorro-antd/table";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  list!: Menu[];
  total = 1;
  loading = false;
  pageSize = 10;
  pageIndex = 1;

  constructor(private service: MenuService) {
  }

  ngOnInit(): void {
  }

  onQueryParamsChange(params: NzTableQueryParams): void {
    const {pageSize, pageIndex} = params;
    this.getAll(pageIndex, pageSize);
  }

  getAll(pageNumber: number, pageSize: number): void {
    this.service.getAll(pageNumber, pageSize).pipe(first()).subscribe((response: any) => {
      this.list = response.data;
      this.total = response.totalCount;
    });
  }

}
