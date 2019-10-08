import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  form: FormGroup;
  tempUser: Client;
  isValid: boolean = null;
  enableSubmit: boolean = false;
  appear1: boolean = true;
  appear2: boolean = false;
  appear3: boolean = false;
  isShow = false;
  firstNo = false;
  secondNo = null;
  finalNo = null;
  result = null;

  constructor(private fb: FormBuilder, private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    this.createForm();
    this.tempUser = <Client>{};
  }

  createForm() {
    this.form = this.fb.group({
      answer0: [false, Validators.required],
      answer1: [false, Validators.required],
      answer2: [false, Validators.required]
    });
  }

  changeValue(valid: boolean) {
    this.isShow = false;
    this.firstNo = !valid;
    this.enableSubmit = !valid;
  }

  changeSecondValue(valid: boolean) {
    this.isShow = false;
    this.secondNo = !valid;
    this.enableSubmit = false;
    this.isValid = valid;
  }

  changeFinalValue(valid: boolean) {
    this.isShow = false;
    this.finalNo = !valid;
  }

  onBack() {
    this.isShow = false;

    if (this.appear3 == true) {
      this.appear1 = false;
      this.appear2 = true;
      this.appear3 = false;
    }

    else if (this.appear2 == true) {
      this.appear1 = true;
      this.appear2 = false;
      this.appear3 = false;
    }
  }

  onNext() {
    this.isShow = false;

    if (this.appear1 == true) {
      this.appear1 = false;
      this.appear2 = true;
      this.appear3 = false;
    }

    else if (this.appear2 == true) {
      this.appear1 = false;
      this.appear2 = false;
      this.appear3 = true;
    }
  }

  onSubmit() {
    // build a temporary user object from form values

    this.tempUser.answers = new Array(3);
    this.tempUser.answers[0] = this.form.value.answer0;
    this.tempUser.answers[1] = this.form.value.answer1;
    this.tempUser.answers[2] = this.form.value.answer2;

    var url = this.baseUrl + "api/DecisionTree/ClientRequest";
    this.http.post<IResult>(url, this.tempUser)
      .subscribe(res => {
        if (res) {
          this.result = res.Result;
        }
        else {
          this.form.setErrors({
            "register": "User registration failed."
          });
        }
      }, error => console.log(error));

    this.isShow = true;
  }
}

interface Client {
  answers: boolean[];
}

interface IResult {
  Result: string;
}
