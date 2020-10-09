import React, {useState, useEffect } from 'react'
import { connect } from 'react-redux';
import * as actions from '../actions/dCandidate';

const DCandidates = (props) => {
    const [x, setX] = useState(0)
    setX(5)

    useEffect(() => {
            props.fetchAllDCandidates()
    }, [])//ComponentDtMount

    return (<div>From DCandidates</div>)
}

const mapStateToProps = state => ({
        dCandidateList : state.dCandidate.list
})

const mapActionToProps = {
    fetchAllDCandidates : actions.fetchAll
}

export default connect(mapStateToProps, mapActionToProps)(DCandidates);


