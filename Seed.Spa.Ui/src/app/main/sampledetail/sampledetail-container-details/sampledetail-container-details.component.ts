//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleDetailService } from '../sampledetail.service';

@Component({
    selector: 'app-sampledetail-container-details',
    templateUrl: './sampledetail-container-details.component.html',
    styleUrls: ['./sampledetail-container-details.component.css'],
})
export class SampleDetailContainerDetailsComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleDetailService: SampleDetailService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleDetailService.initVM();
    }

    ngOnInit() {

       
    }

}
