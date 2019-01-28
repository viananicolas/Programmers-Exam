import React from "react";
import { connect } from "react-redux";
import InputMask from "react-input-mask";
import { getPlays, handleSubmit } from "../actions";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";

const reactSwal = withReactContent(Swal);

class Home extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      play: "",
      plays: [],
      name: "",
      telephone: "",
      email: "",
      audience: 1,
      disabled: false
    };
  }
  onChange = event => {
    this.setState({
      [event.target.name]: event.target.value
    });
  };
  componentWillMount = async () => {
    let plays = await getPlays();
    console.log(plays);
    this.setState({ plays });
  };
  submitForm = async event => {
    try {
      this.setState({ disabled: true });
      let result = await handleSubmit(event);
      if (result.status === 200) {
        this.setState({ name: "", telephone: "", email: "", audience: 1 });
        reactSwal.fire({
          title: "Info",
          html: `Successfully registered order. Total: ${
            result.data.totalPrice
          }`,
          type: "success"
        });
      } else reactSwal.fire("Info", `Error while registering order.`, "error");
      this.setState({ disabled: false });
      console.log(result);
    } catch (error) {
      reactSwal.fire("Info", `Error while registering order.`, "error")
    }
  };

  renderPlays = data => {
    if (data) {
      return (
        <div>
          <label htmlFor="playId">Select Play</label>
          <select
            name="playId"
            value={this.state.play}
            onChange={this.onChange}
            className="form-control"
          >
            {data.map((play, key) => {
              return (
                <option key={play.id} value={play.id}>
                  {play.playName}
                </option>
              );
            })}
          </select>
        </div>
      );
    }
    return <div />;
  };

  render() {
    return (
      <div>
        <form onSubmit={event => this.submitForm(event, this.state)}>
          {this.renderPlays(this.state.plays)}
          <div className="form-group">
            <label htmlFor="audience">Enter Audience</label>
            <input
              name="audience"
              type="number"
              className="form-control"
              value={this.state.audience}
              onChange={this.onChange}
            />
          </div>
          <div className="form-group">
            <label htmlFor="name">Enter Name</label>
            <input
              name="name"
              type="text"
              className="form-control"
              value={this.state.name}
              onChange={this.onChange}
            />
          </div>
          <div className="form-group">
            <label htmlFor="email">Enter Email</label>
            <input
              name="email"
              type="email"
              className="form-control"
              value={this.state.email}
              onChange={this.onChange}
            />
          </div>
          <div className="form-group">
            <label htmlFor="telephone">Enter Telephone</label>
            <InputMask
              name="telephone"
              type="tel"
              mask="(99) 99999-9999"
              value={this.state.telephone}
              onChange={this.onChange}
              className="form-control"
            />
          </div>
          <input
            type="submit"
            value="Submit"
            className="btn btn-primary"
            disabled={this.state.disabled ? "disabled" : ""}
          />
        </form>
      </div>
    );
  }
}

export default connect(state => state.weatherForecasts)(Home);
