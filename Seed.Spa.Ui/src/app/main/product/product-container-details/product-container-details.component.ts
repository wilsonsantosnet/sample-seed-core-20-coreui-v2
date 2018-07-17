//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ProductService } from '../product.service';

@Component({
    selector: 'app-product-container-details',
    templateUrl: './product-container-details.component.html',
    styleUrls: ['./product-container-details.component.css'],
})
export class ProductContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private productService: ProductService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.productService.initVM();
    }

    ngOnInit() {

       
    }

}
