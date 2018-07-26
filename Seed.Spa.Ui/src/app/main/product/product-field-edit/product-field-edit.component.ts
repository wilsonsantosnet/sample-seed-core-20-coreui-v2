import { Component, OnInit, Input, ChangeDetectorRef, ViewChild } from '@angular/core';
import { ProductService } from '../product.service';

import { ViewModel } from '../../../common/model/viewmodel';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-product-field-edit',
    templateUrl: './product-field-edit.component.html',
    styleUrls: ['./product-field-edit.component.css']
})
export class ProductFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


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
