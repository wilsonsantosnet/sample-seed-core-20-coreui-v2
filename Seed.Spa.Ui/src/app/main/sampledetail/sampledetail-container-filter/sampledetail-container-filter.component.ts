//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleDetailService } from '../sampledetail.service';

@Component({
    selector: 'app-sampledetail-container-filter',
    templateUrl: './sampledetail-container-filter.component.html',
    styleUrls: ['./sampledetail-container-filter.component.css'],
})
export class SampleDetailContainerFilterComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private sampleDetailService: SampleDetailService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleDetailService.initVM();
    }

    ngOnInit() {

       
    }

}
