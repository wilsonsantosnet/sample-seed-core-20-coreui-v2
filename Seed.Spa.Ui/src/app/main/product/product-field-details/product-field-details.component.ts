
import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-product-field-details',
    templateUrl: './product-field-details.component.html',
    styleUrls: ['./product-field-details.component.css']
})
export class ProductFieldDetailsComponent implements OnInit {


    @Input() vm: ViewModel<any>;

    constructor() { }

    ngOnInit() {

    }

}
