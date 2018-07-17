//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleProductService } from '../sampleproduct.service';

@Component({
    selector: 'app-sampleproduct-container-filter',
    templateUrl: './sampleproduct-container-filter.component.html',
    styleUrls: ['./sampleproduct-container-filter.component.css'],
})
export class SampleProductContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private sampleProductService: SampleProductService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleProductService.initVM();
    }

    ngOnInit() {

       
    }

}
