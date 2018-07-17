import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';

import { ProductService } from '../product.service';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-product-field-edit',
    templateUrl: './product-field-edit.component.html',
    styleUrls: ['./product-field-edit.component.css']
})
export class ProductFieldEditComponent implements OnInit {

    @Input() vm: ViewModel<any>


    constructor(private productService: ProductService, private ref: ChangeDetectorRef) { }

    ngOnInit() { }

    ngOnChanges() {
       this.ref.detectChanges()
    }

        

   
}
