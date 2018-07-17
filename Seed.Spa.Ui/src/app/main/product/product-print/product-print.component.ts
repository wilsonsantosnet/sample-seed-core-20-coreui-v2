import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';

import { ProductService } from '../product.service';
import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-product-print',
    templateUrl: './product-print.component.html',
    styleUrls: ['./product-print.component.css'],
})
export class ProductPrintComponent implements OnInit {

    vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private productService: ProductService, private route: ActivatedRoute) {
        this.vm = this.productService.initVM();
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this.id = params['id']; 
        });

        if (this.id)
        {
            this.productService.get({ id: this.id }).subscribe((data) => {
                this.vm.details = data.data;
            });
        }

    }
    
    onPrint() {
        window.print();
    }
   


}
