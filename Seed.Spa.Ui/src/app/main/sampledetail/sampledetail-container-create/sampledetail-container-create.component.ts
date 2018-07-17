//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleDetailService } from '../sampledetail.service';

@Component({
    selector: 'app-sampledetail-container-create',
    templateUrl: './sampledetail-container-create.component.html',
    styleUrls: ['./sampledetail-container-create.component.css'],
})
export class SampleDetailContainerCreateComponent implements OnInit {

    @Input() vm: ViewModel<any>;
  
    constructor(private sampleDetailService: SampleDetailService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleDetailService.initVM();
    }

    ngOnInit() {

       
    }

}
