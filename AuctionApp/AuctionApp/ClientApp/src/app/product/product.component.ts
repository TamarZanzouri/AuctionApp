import { Component, OnInit, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { debug } from 'util';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() id : number;
  @Input() name: string;
  @Input() image: string;
  @Input() endDate: string;
  @Input() memberId : number;
  @Input() notAvailble : boolean = false;
  itemAvalible : boolean = true;
  bidAmount : number;
  baseUrl : string;
  memberBid : MemberBid;

  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl;
  }

  ngOnInit() {
  }

  
  bid(){
      this.memberBid =  {
            itemId : this.id,
            bidAmount : this.bidAmount,
            memberId : this.memberId
          };
            this.http.post(this.baseUrl + 'api/Auction', this.memberBid).subscribe(result => {
            
    }, error => console.error(error));
  }
}

interface MemberBid {
    memberId : number;
    itemId : number;
    //memberEmail : string;
    bidAmount : number;
}
