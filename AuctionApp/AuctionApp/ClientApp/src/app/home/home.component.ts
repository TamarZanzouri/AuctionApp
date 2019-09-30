import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

    private products : Product[];
    private memberBids : number[];
    private memberId : number = 1;

      constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

      http.get<Product[]>(baseUrl + 'api/Auction').subscribe(result => {
      this.products = result;
      http.get<any>(baseUrl + 'api/Auction/GetMemberBids?id=' + this.memberId).subscribe(result => {
          this.memberBids = result.memberBids;
          this.products.forEach(item => {
              item.NotAvailble = this.memberBids.indexOf(item.Id) > -1 ? true : false;
          });
      },error => console.error(error));
    }, error => console.error(error));
  }
}

interface Product {
    Id : number;
    Name : string;
    EndDate : string;
    NotAvailble : boolean;
}
