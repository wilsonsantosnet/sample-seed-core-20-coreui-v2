import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { ProductService } from '../product.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GlobalService, NotificationParameters } from '../../../global.service';

@Component({
    selector: 'app-product-field-create',
    templateUrl: './product-field-create.component.html',
    styleUrls: ['./product-field-create.component.css']
})
export class ProductFieldCreateComponent implements OnInit {

   @Input() vm: ViewModel<any>;

   constructor(private productService: ProductService, private ref: ChangeDetectorRef) { }

   ngOnInit() {}


    ngOnChanges() {
       this.ref.detectChanges()
    }

    onSaveEnd(model: any) {
       
    }

    onBackEnd(model: any) {
       
    }

   


}
