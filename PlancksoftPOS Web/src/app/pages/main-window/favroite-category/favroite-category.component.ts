import { Component, OnInit } from "@angular/core";
import { LocalDataSource } from "ng2-smart-table";
import { SmartTableData } from "../../../@core/data/smart-table";
import {
  NbDialogService,
  NbSortDirection,
  NbSortRequest,
  NbToastrService,
  NbTreeGridDataSource,
  NbTreeGridDataSourceBuilder,
} from "@nebular/theme";
import { PublisherService } from "../../../services/publisher.service";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: "ngx-favroite-category",
  templateUrl: "./favroite-category.component.html",
  styleUrls: ["./favroite-category.component.scss"],
})
export class FavroiteCategoryComponent implements OnInit {
  message: any;
  dltId: any;
  data: any;
  Check: any;

  itemGroup: FormGroup;

  defaultColumns = [" ID", " Name", "Action"];
  allColumns = [...this.defaultColumns];

  dataSource: NbTreeGridDataSource<any>;

  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;

  constructor(
    private service: SmartTableData,
    private dialogService: NbDialogService,
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private toastrService: NbToastrService,
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<any>
  ) {
    const data = this.service.getData();
  }

  delete(event): void {
    ;
    this.dltId = event;

    if (this.dltId > 0) {
      var obj = {
        FavoriteCategoryID: this.dltId,
      };

      this.publisherService
        .PostRequest("DeleteFavoriteCategory", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
          this.ngOnInit();
        });
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  ngOnInit(): void {
    this.itemGroup = this.fb.group({
      categoryname: [""],
    });

    this.publisherService
      .PostRequest("RetrieveFavoriteCategories", "")
      .subscribe((res: any) => {
        console.log(JSON.parse(res));

        var response = JSON.parse(res);
        var message = response.ResponseMessage;

        var list = [];
        message.forEach((el) => {
          var obj = {
            data: {
              id: el["ID"],
              Name: el["Name"],
            },
          };
          list.push(obj);
        });

        this.data = list;
        this.dataSource = this.dataSourceBuilder.create(this.data);

        console.log(this.dataSource);
      });
  }

  SubmitData() {
    if (this.itemGroup.valid) {
      console.log(this.itemGroup.value);
      var obj = {
        FavoriteCategory: this.itemGroup.value.categoryname,
      };

      this.publisherService
        .PostRequest("InsertFavoriteCategory", obj)
        .subscribe((res: any) => {
          console.log(JSON.parse(res));
          this.ngOnInit();
        });
    } else {
      this.toastrService.danger("Try Again", "Error");
    }
  }

  Update(Id) {
    var selected = this.data.filter((a) => a.data.id == Id)[0];
    this.Check = selected.data.id;

    this.itemGroup.patchValue({
      categoryname: selected.data.Name,
    });
  }

  Updatedata() {
    var obj = {
      FavoriteCategory: this.itemGroup.value.categoryname,
      FavoriteCategoryID: this.Check,
    };

    this.publisherService
      .PostRequest("UpdateFavoriteCategories", obj)
      .subscribe((res: any) => {
        console.log(JSON.parse(res));
        this.ngOnInit();
      });
  }

  updateSort(sortRequest: NbSortRequest): void {
    this.sortColumn = sortRequest.column;
    this.sortDirection = sortRequest.direction;
  }

  getSortDirection(column: string): NbSortDirection {
    if (this.sortColumn === column) {
      return this.sortDirection;
    }
    return NbSortDirection.NONE;
  }
  getShowOn(index: number) {
    const minWithForMultipleColumns = 400;
    const nextColumnStep = 100;
    return minWithForMultipleColumns + nextColumnStep * index;
  }
}
