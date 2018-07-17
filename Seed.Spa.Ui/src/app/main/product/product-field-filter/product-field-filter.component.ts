import { Component, OnInit, Input } from '@angular/core';

import { ViewModel } from '../../../common/model/viewmodel';

@Component({
    selector: 'app-product-field-filter',
    templateUrl: './product-field-filter.component.html',
    styleUrls: ['./product-field-filter.component.css']
})
export class ProductFieldFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>

    constructor() { }

    ngOnInit() {
    }

}
