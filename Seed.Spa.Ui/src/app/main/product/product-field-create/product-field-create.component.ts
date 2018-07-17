import { Component, OnInit, Input, ChangeDetectorRef} from '@angular/core';
import { ProductService } from '../product.service';

import { ViewModel } from '../../../common/model/viewmodel';

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

   


}
