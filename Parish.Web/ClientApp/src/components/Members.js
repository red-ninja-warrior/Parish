import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { memberActions } from '../store/MemberStore';

class Members extends Component {
  componentDidMount() {
    // This method is called when the component is first added to the document
    this.fetchFamilyMembers();
  }

  fetchFamilyMembers() {
      this.props.members();
  }

  render() {
    return (
      <div>
        <h1>Family Members</h1>
        <p>Below are the list of Family Members</p>
        {renderFamilyMembers(this.props)}
      </div>
    );
  }
}

function renderFamilyMembers(props) {
    return (
        <table className='table table-striped'>
            <thead>
                <tr>
                    <th>Family</th>
                    <th>Member</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>Is Primary Member</th>
                    <th>Is Registered Family</th>
                </tr>
            </thead>
            <tbody>
                {props && props.familyMembers && props.familyMembers.map(fm =>
                    <tr key={fm.familyMemberId}>
                        <td>{fm.familyName}</td>
                        <td>{fm.firstName + " " + fm.lastName}</td>
                        <td>{fm.email}</td>
                        <td>{fm.phone}</td>
                        <td>{fm.isPrimaryMember ? "Yes" : "No"}</td>
                        <td>{fm.isRegistered ? "Yes" : "No"}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );    
}

export default connect(
    state => state.familyMembers,
    dispatch => bindActionCreators(memberActions, dispatch)
)(Members);
