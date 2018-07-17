//EXT
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ModalDirective } from 'ngx-bootstrap/modal';
import { ViewModel } from '../../../common/model/viewmodel';
import { SampleDetailService } from '../sampledetail.service';

@Component({
    selector: 'app-sampledetail-container-edit',
    templateUrl: './sampledetail-container-edit.component.html',
    styleUrls: ['./sampledetail-container-edit.component.css'],
})
export class SampleDetailContainerEditComponent implements OnInit {

    @Input() vm: ViewModel<any>;
    id: number;
    private sub: any;

    constructor(private sampleDetailService: SampleDetailService, private route: ActivatedRoute, private router: Router) {

        this.vm = this.sampleDetailService.initVM();
    }

    ngOnInit() {

       
    }

}
