//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { ProductService } from '../product.service';

@Component({
    selector: 'app-product-container-create',
    templateUrl: './product-container-create.component.html',
    styleUrls: ['./product-container-create.component.css'],
})
export class ProductContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private productService: ProductService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.productService.initVM();
    }

    ngOnInit() {

       
    }

}
